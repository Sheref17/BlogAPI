using ApplicationLayer.CustomExceptions;
using ApplicationLayer.CustomExceptions.ConflictExceptions;
using CoreLayer.Entities;
using CoreLayer.IRepos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.CQRS.Categroy.Commands.Create
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, bool>
    {
        private readonly ICategroyRepository _categroyRepository;

        public CreateCategoryHandler(ICategroyRepository categroyRepository)
        {
            _categroyRepository = categroyRepository;
        }
        public async Task<bool> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var exististCategory = await _categroyRepository.CategoryNameExist(request.Name);
            if(exististCategory) throw new CategroyWithThisNameExistException(request.Name);

            var category = new Category(request.Name);

            await _categroyRepository.AddAsync(category);
            await _categroyRepository.SaveChangesAsync();
            return true;


        }
    }
}
