using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore.Utilities;

namespace core.Extensions
{
    public static class IIncludableQueryable<TEntity, TProperty> Include<TEntity, TProperty>(this IQueryable<TEntity> source, Expression<Func<TEntity, TProperty>> navigationPropertyPath) where TEntity : class
        {
            Microsoft.EntityFrameworkCore.Utilities..Check.NotNull(source, "source");
            Microsoft.EntityFrameworkCore.Utilities..Check.NotNull(navigationPropertyPath, "navigationPropertyPath");
            return new IncludableQueryable<TEntity, TProperty>((IQueryable<TEntity>)((source.Provider is EntityQueryProvider) ? ((IQueryable<object>)source.Provider.CreateQuery<TEntity>(Expression.Call(null, IncludeMethodInfo.MakeGenericMethod(typeof(TEntity), typeof(TProperty)), new Expression[2]
            {
                source.Expression,
                Expression.Quote(navigationPropertyPath)
            }))) : ((IQueryable<object>)source)));
        }

        internal static IIncludableQueryable<TEntity, TProperty> NotQuiteInclude<TEntity, TProperty>(this IQueryable<TEntity> source, Expression<Func<TEntity, TProperty>> navigationPropertyPath) where TEntity : class
        {
            return new IncludableQueryable<TEntity, TProperty>((IQueryable<TEntity>)((source.Provider is EntityQueryProvider) ? ((IQueryable<object>)source.Provider.CreateQuery<TEntity>(Expression.Call(null, NotQuiteIncludeMethodInfo.MakeGenericMethod(typeof(TEntity), typeof(TProperty)), new Expression[2]
            {
                source.Expression,
                Expression.Quote(navigationPropertyPath)
            }))) : ((IQueryable<object>)source)));
        }

        //
        // Resumo:
        //     Specifies additional related data to be further included based on a related type
        //     that was just included.
        //
        // Parâmetros:
        //   source:
        //     The source query.
        //
        //   navigationPropertyPath:
        //     A lambda expression representing the navigation property to be included (t =>
        //     t.Property1).
        //
        // Parâmetros de Tipo:
        //   TEntity:
        //     The type of entity being queried.
        //
        //   TPreviousProperty:
        //     The type of the entity that was just included.
        //
        //   TProperty:
        //     The type of the related entity to be included.
        //
        // Devoluções:
        //     A new query with the related data included.
        //
    }
