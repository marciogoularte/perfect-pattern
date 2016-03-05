﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Omu.ValueInjecter;

namespace PerfectPattern.Common.Extensions
{
    /// <summary>
    /// Extension methods for mapping entities to DTOs
    /// </summary>
    public static class DTOExtensions
    {
        /// <summary>
        /// Extension method for IEnumerable to map them to DTO of type T
        /// </summary>
        /// <typeparam name="T">DTO type</typeparam>
        /// <param name="obj">Collection of entities</param>
        /// <returns>Collection of DTO</returns>
        public static IEnumerable<T> ToDTO<T>(this IEnumerable<object> obj) where T : class, new()
        {
            if (obj == null) return null;

            return obj.ToList().Select(x => new T().InjectFrom(x)).Cast<T>();
        }

        public static T ToDTO<T>(this object obj) where T : class, new()
        {
            if (obj == null) return null;

            return new T().InjectFrom(obj) as T;
        }
    }
}
