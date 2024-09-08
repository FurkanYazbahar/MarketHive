﻿
namespace Basket.API.Basket.DeleteBasket
{
    public record DeleteBasketCommand(string UserName) : ICommand<DeleteBasketResult>;
    public record DeleteBasketResult(bool IsSuccess);

    public class DeleteBasketCommandValidator : AbstractValidator<DeleteBasketCommand>
    {
        public DeleteBasketCommandValidator() 
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName is required");        
        }
    }
    public class DeleteBasketCommandHandler :
        ICommandHandler<DeleteBasketCommand, DeleteBasketResult>
    {
        public async Task<DeleteBasketResult> Handle(DeleteBasketCommand command, CancellationToken cancellationToken)
        {
            // TODO: delete basket from database and cache
            //session.Delete<Product>(command.Id);

            return new DeleteBasketResult(true);
        }
    }
}
