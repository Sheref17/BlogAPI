using ApplicationLayer.CustomExceptions;
using ApplicationLayer.CustomExceptions.ConflictExceptions;
using ApplicationLayer.CustomExceptions.NotFoundExceptions;
using CoreLayer.IRepos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.CQRS.Categroy.Commands.Update
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, bool>
    {
        private readonly ICategroyRepository _categroyRepository;

        public UpdateCategoryHandler(ICategroyRepository categroyRepository)
        {
            _categroyRepository = categroyRepository;
        }
        public async Task<bool> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categroyRepository.GetByIdAsync(request.Id);
            if(category is null) throw new CategroyNotFoundException(request.Id);

            var categoryNameExist = await _categroyRepository.CategoryNameExist(request.Name);
            if (categoryNameExist) throw new CategroyWithThisNameExistException(request.Name);

            category.Update(request.Name);

            await _categroyRepository.SaveChangesAsync();

            return true;
        }
    }
}
