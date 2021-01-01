using AutoMapper;
using CodersAcademyBootcamp.Application.Account.Dto.ChangePassword;
using CodersAcademyBootcamp.Application.Account.Dto.CreateAccount;
using CodersAcademyBootcamp.Application.Account.Dto.ForgetPassword;
using CodersAcademyBootcamp.Application.Account.Service.Interfaces;
using CodersAcademyBootcamp.Crosscutting.Exception;
using CodersAcademyBootcamp.Crosscutting.Notification;
using CodersAcademyBootcamp.Crosscutting.Proxy;
using CodersAcademyBootcamp.Crosscutting.Specification;
using CodersAcademyBootcamp.Crosscutting.Storage;
using CodersAcademyBootcamp.Domain.Account;
using CodersAcademyBootcamp.Domain.Account.Aggregate.Event;
using CodersAcademyBootcamp.Domain.Account.Enumeration;
using CodersAcademyBootcamp.Domain.Account.Repository;
using CodersAcademyBootcamp.Domain.Account.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodersAcademyBootcamp.Application.Account.Service
{
    public class AccountService : IAccountService
    {

        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        private readonly AzureCloudStorage storage;
        private readonly string DefaultPhoto = @"https://robohash.org/{0}?bgset=any";
        private IEventPublisher EventPublisher { get; set; }

        public AccountService(IUserRepository userRepository, IMapper mapper, AzureCloudStorage storage, IEventPublisher eventPublisher)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.storage = storage;
            this.EventPublisher = eventPublisher;
        }

        public async Task<CreateAccountOutputDto> CreateAccount(CreateAccountInputDto request)
        {
            var businessExpection = new BusinessException();

            if ((await this.userRepository.GetAllByCriteria(UserSpecification.GetUserByEmail(request.Email))).Any())
                businessExpection.AddError(new BusinessValidationFailure() { ErrorMessage = "E-mail já cadastrado na base, por favor tente outro" });

            if ((await this.userRepository.GetAllByCriteria(UserSpecification.GetUserByCPF(request.CPF))).Any())
                businessExpection.AddError(new BusinessValidationFailure() { ErrorMessage = "CPF já cadastrado na base, por favor tente outro" });

            businessExpection.ValidateAndThrow();

            var user = this.mapper.Map<User>(request);
            user.ApplyStatus(Status.CONFIRMACAO_EMAIL);

            user.Validate();

            user.ApplyPassword();


            using (var transaction = await this.userRepository.CreateTransaction())
            {
                try
                {
                    var ms = ProxyUtils.DownloadFromUrl(String.Format(this.DefaultPhoto, Guid.NewGuid().ToString()));
                    user.Photo = await this.storage.SaveToStorage(AzureCloudImageDirectoryStorageEnum.USER, ms, String.Format("{0}.jpg", Guid.NewGuid().ToString().Replace("-", "")));

                    await this.userRepository.Save(user);
                    await transaction.CommitAsync();

                    var notification = new NotificationMessage(user.Email.Valor, new Message(new
                    {
                        Email = user.Email.Valor,
                        FullName = user.Name,
                        Id = user.Id
                    }));


                    CreatedAccountEvent accountEvent = new CreatedAccountEvent(CreatedAccountEvent.CREATE_ACCOUNT_EVENT, notification);

                    await this.EventPublisher.Publish<CreatedAccountEvent>(accountEvent);

                    return this.mapper.Map<CreateAccountOutputDto>(user);

                    
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }

        }

        public async Task ForgetPassword(ForgetPasswordInputDto request)
        {
            var businessExpection = new BusinessException();

            var user = await this.userRepository.GetOneByCriteria(UserSpecification.GetUserByEmail(request.Email));

            if (user == null)
                businessExpection.AddError(new BusinessValidationFailure() { ErrorMessage = "E-mail não encontrado em nossa base de dados, por favor verifique o email e tente denovo", ErrorName = "ForgetPassword.EmailNãoCadastrado" });

            businessExpection.ValidateAndThrow();
            user.ChangePassword(request.Password);

            using (var transaction = await this.userRepository.CreateTransaction())
            {
                try
                {
                    await this.userRepository.Update(user);
                    await transaction.CommitAsync();


                    var notification = new NotificationMessage(user.Email.Valor, new Message(new
                    {
                        Email = user.Email.Valor,
                        FullName = user.Name
                    }));

                    ChangePasswordConfirmEvent accountEvent = new ChangePasswordConfirmEvent(ChangePasswordConfirmEvent.CHANGE_PASSWORD_CONFIRMED_EVENT, notification);

                    await this.EventPublisher.Publish<ChangePasswordConfirmEvent>(accountEvent);
                }
                catch
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }
    }
}
