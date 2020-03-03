using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRMALL.Teste.Domain.Helper
{
    public static class MapperHelper
    {
        public static IEnumerable<TDestiny> CopyList<TSource, TDestiny>(IEnumerable<TSource> src)
        {
            var ret = new List<TDestiny>();
            if (src is null)
            {
                return ret;
            }

            ret.AddRange(src.Select(origin => (TDestiny)Mapper.Map(origin, typeof(TSource), typeof(TDestiny))));
            return ret;
        }

        public static TDestiny Map<TSource, TDestiny>(TSource origin)
        {
            return Mapper.Map<TDestiny>(origin);
        }
    }
}
