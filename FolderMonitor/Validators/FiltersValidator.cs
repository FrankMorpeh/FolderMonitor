using FolderMonitor.Warnings;
using System;
using System.Collections.Generic;

namespace FolderMonitor.Validators
{
    public static class FiltersValidator
    {
        public static IWarning CheckFilters(List<string> filters)
        {
            bool isValid = true;

            foreach (string filter in filters)
            {
                if (filter.Length == 0)
                    isValid = false;
                for (int j = 0; j < filter.Length; j++)
                {
                    if (j == 0) // if it's the first symbol, then it should be '*'
                    {
                        if (filter[j] != '*')
                            isValid = false;
                    }
                    else if (j == 1) // if it's the second symbol. then it should be '.' 
                    {
                        if (filter[j] != '.')
                            isValid = false;
                    }
                    else // if it's not the first and the second, then it should be a letter of a digit
                    {
                        if (!Char.IsLetterOrDigit(filter[j]))
                            isValid = false;
                    }
                }
            }

            if (isValid)
                return new None();
            else
                return new IncorrectFilter();
        }
    }
}