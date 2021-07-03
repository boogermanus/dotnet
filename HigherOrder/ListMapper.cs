using System;
using System.Collections.Generic;
namespace HigherOrder.Mapper
{
    public class ListMapper
    {
        public static List<TOut> Map<TIn, TOut>(List<TIn> list, Func<TIn, TOut> mapper)
        {
            var newList = new List<TOut>();
            
            list.ForEach(item => {
                var newItem = mapper(item);
                newList.Add(newItem);
            });

            return newList;
        }
    }
}