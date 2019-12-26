using Extensions;
using System.Collections.Generic;

namespace System.Linq
{
    public static class LinqResponseExtensions
    {
        public static Response<TSource> SingleResponse<TSource>(this IEnumerable<TSource> enumerable, string error = "")
        {
            var result = enumerable.SingleOrDefault();
            return CreateResponse(error, result);
        }

        public static Response<TSource> FirstResponse<TSource>(this IEnumerable<TSource> enumerable, string error = "")
        {
            var result = enumerable.FirstOrDefault();
            return CreateResponse(error, result);
        }

        public static Response<IEnumerable<TSource>> AnyResponse<TSource>(this IEnumerable<TSource> enumerable, string error = "")
        {
            if (enumerable.Any())
            {
                return Response<IEnumerable<TSource>>.Ok(enumerable);
            }

            return Response<IEnumerable<TSource>>.Error(error);
        }

        private static Response<TSource> CreateResponse<TSource>(string error, TSource result)
        {
            if (result == null)
            {
                return Response<TSource>.Error(error);
            }

            return Response<TSource>.Ok(result);
        }
    }
}
