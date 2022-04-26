﻿using System.Diagnostics.CodeAnalysis;
using System.Threading;

namespace Microsoft.AspNetCore.Builder
{

    /// <summary>
    /// 
    /// </summary>
    public static class IApplicationBuilderExtensions
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        [SuppressMessage("Reliability", "CA2007:Consider calling ConfigureAwait on the awaited task", Justification = "<Pending>")]
        public static IApplicationBuilder UseThreadPrincipals(this IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                Thread.CurrentPrincipal = context.User;
                await next();
            });
            return app;
        }

    }

}
