using System;

// ReSharper disable once CheckNamespace
namespace Microsoft.AspNetCore.Hosting
{
    /// <summary>
    /// Hosting environment extensions.
    /// </summary>
    public static class HostingEnvironmentExtensions
    {
        /// <summary>
        /// Checks if the current hosting environment name is "Localhost".
        /// </summary>
        /// <param name="hostingEnvironment">An instance of <see cref="T:Microsoft.AspNetCore.Hosting.IHostingEnvironment" />.</param>
        /// <returns>True if the environment name is "Development", otherwise false.</returns>
        public static bool IsLocal(this IHostingEnvironment hostingEnvironment)
        {
            if (hostingEnvironment == null)
                throw new ArgumentNullException(nameof(hostingEnvironment));
            return hostingEnvironment.IsEnvironment("Localhost");
        }
    }
}
