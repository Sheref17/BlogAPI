using ApplicationLayer.CustomExceptions;
using ApplicationLayer.CustomExceptions.NotFoundExceptions;
using CoreLayer.IRepos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.CQRS.Categroy.Commands.Delete
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, bool>
    {
        private readonly ICategroyRepository _categroyRepository;

        public DeleteCategoryHandler(ICategroyRepository categroyRepository)    
        {
            _categroyRepository = categroyRepository;
        }
        public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
           var category = await _categroyRepository.GetByIdAsync(request.Id);
            if (category is null)
                throw new CategroyNotFoundException(request.Id);

          await  _categroyRepository.DeleteAsync(category);
            await _categroyRepository.SaveChangesAsync();

            return true;

        }
    }
}
