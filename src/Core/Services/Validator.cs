using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nandel.StikyNotes.Core.Specifications;

namespace Nandel.StikyNotes.Core.Services
{
    public class Validator<T> : IValidator<T>
    {
        private readonly IEnumerable<ISpecification<T>> _specs;

        public Validator(IEnumerable<ISpecification<T>> specs)
        {
            _specs = specs;
        }

        public async Task ValidateAsync(T instance)
        {
            foreach (var spec in _specs.Where(x => x.IsApplicableTo(instance)))
            {
                if (! await spec.IsSatisfiedByAsync(instance))
                {
                    throw new InvalidOperationException(spec.GetErrorMessage(instance));
                }
            }
        }
    }
}