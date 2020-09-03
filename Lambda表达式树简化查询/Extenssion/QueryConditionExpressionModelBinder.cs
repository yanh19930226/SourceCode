using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using System.Web.Http.ModelBinding;
using System.Web.Http.ValueProviders;

namespace Lambda表达式树简化查询.Extenssion
{

    //参考资料：
    public class QueryConditionExpressionModelBinder : IModelBinder
    {
        public bool BindModel(System.Web.Http.Controllers.HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            var modelType = GetModelTypeFromExpressionType(bindingContext.ModelType);
            if (modelType == null) return false;

            var body = default(Expression);
            var parameter = Expression.Parameter(modelType, modelType.Name);

            foreach (var property in modelType.GetProperties())
            {
                var queryValue = GetValueAndHandleModelState(property, bindingContext.ValueProvider, controllerContext.Controller);
                if (queryValue == null) continue;

                Expression proeprtyCondition = null;
                if (property.PropertyType == typeof(string))
                {
                    if (!string.IsNullOrEmpty(queryValue as string))
                    {
                        proeprtyCondition = parameter.Property(property.Name)
                            .Call("Contains", Expression.Constant(queryValue));
                    }
                }
                else if (property.PropertyType == typeof(DateTime?))
                {
                    proeprtyCondition = parameter
                        .Property(property.Name)
                        .Property("Value")
                        .Property("Date")
                        .Equal(Expression.Constant(queryValue));
                }
                else
                {
                    proeprtyCondition = parameter
                        .Property(property.Name)
                        .Equal(Expression.Constant(queryValue));
                }
                if (proeprtyCondition != null)
                    body = body != null ? body.AndAlso(proeprtyCondition) : proeprtyCondition;
            }
            if (body == null) body = Expression.Constant(true);
            return body.ToLambda(parameter);
        }
        /// <summary>
        /// 获取 Expression<Func<TXXX, bool>> 中 TXXX 的类型
        /// </summary>
        private Type GetModelTypeFromExpressionType(Type lambdaExpressionType)
        {

            if (lambdaExpressionType.GetGenericTypeDefinition() != typeof(Expression<>)) return null;

            var funcType = lambdaExpressionType.GetGenericArguments()[0];
            if (funcType.GetGenericTypeDefinition() != typeof(Func<,>)) return null;

            var funcTypeArgs = funcType.GetGenericArguments();
            if (funcTypeArgs[1] != typeof(bool)) return null;
            return funcTypeArgs[0];
        }
        /// <summary>
        /// 获取属性的查询值并处理 Controller.ModelState 
        /// </summary>
        private object GetValueAndHandleModelState(PropertyInfo property, IValueProvider valueProvider, System.Web.Mvc.ControllerBase controller)
        {
            var result = valueProvider.GetValue(property.Name);
            if (result == null) return null;

            var modelState = new ModelState { Value = result };
            controller.ViewData.ModelState.Add(property.Name, modelState);

            object value = null;
            try
            {
                value = result.ConvertTo(property.PropertyType);
            }
            catch (Exception ex)
            {
                modelState.Errors.Add(ex);
            }
            return value;
        }
    }
}