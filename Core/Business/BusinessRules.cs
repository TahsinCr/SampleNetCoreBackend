﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;

namespace Core.Business
{
    public static class BusinessRules
    {
        public static IResult? Run(params IResult[][] logicArgs)
        {
            foreach (var logics in logicArgs)
            {
                foreach (var logic in logics)
                {
                    if (!logic.Success)
                    {
                        return logic;
                    }
                }
            }
            return null;
        }
    }
}
