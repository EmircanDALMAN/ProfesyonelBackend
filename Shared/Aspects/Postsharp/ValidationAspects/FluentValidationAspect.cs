using System;
using System.Linq;
using FluentValidation;
using PostSharp.Aspects;
using Shared.CrossCuttingConcerns.Validation.FluentValidation;

namespace Shared.Aspects.Postsharp.ValidationAspects
{
    [Serializable]
    public class FluentValidationAspect : OnMethodBoundaryAspect
    {
        private Type _validatorType;

        public FluentValidationAspect(Type validatorType)
        {
            _validatorType = validatorType;
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = args.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
