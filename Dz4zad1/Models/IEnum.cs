using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dz4zad1.Models
{
    public static class IEnum
    {
        public static IEnumerable<Author> Add(this IEnumerable<Author> e, Author value)
        {
            foreach (var cur in e)
            {
                yield return cur;
            }
            yield return value;
        }

        public static IEnumerable<Author> Delete(this IEnumerable<Author> e, int id)
        {
            foreach (Author VARIABLE in e)
            {
                if (VARIABLE.Id != id)
                {
                    yield return VARIABLE;
                }
            }
        }

        public static Author Back_Author(this IEnumerable<Author> e,int id)
        {
            foreach (var cur in e)
            {
                if (cur.Id == id)
                    return cur;
            }

            return null;
        }

        public static IEnumerable<Author> Clear(this IEnumerable<Author> e)
        {
            int i = 0;
            foreach (var VARIABLE in e)
            {
                if (VARIABLE.Id == i)
                {
                    yield return VARIABLE;
                }
            }
        }

        public static IEnumerable<Author> Checking(this IEnumerable<Author> e, IEnumerable<Author> item)
        {
            foreach (Author VARIABLE in item)
            {
                foreach (Author VAR in e)
                {
                    if (VARIABLE.Id == VAR.Id)
                    {
                        yield return VARIABLE;
                    }
                }
            }
        }
    }
}