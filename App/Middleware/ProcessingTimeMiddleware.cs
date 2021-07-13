
// using System;
// using System.Diagnostics;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Http;

// namespace App.Middleware
// {
//     public class ProcessingTimeMiddleware
//     {


//         private const string RESPONSE_HEADER_RESPONSE_TIME = "X-Processing-Time-Milliseconds";
//         private const string RESPONSE_HEADER_APP_INSTANCE = "X-AppInstance";
        
//         // private string appInstance;
//         public string AppInstance { get; set; } = "01";
//         // {
//         //     get
//         //     {
//         //         if (appInstance == null)
//         //             throw new Exception("AppInstance not initialized");
//         //         else
//         //             return appInstance;
//         //     }
//         //     set
//         //     {
//         //         if (value == null)
//         //             throw new Exception("Can not initialize AppInstance to null");
//         //         else
//         //             appInstance = value;

//         //     }
//         // }

//         private readonly RequestDelegate _next;

//         public ProcessingTimeMiddleware(RequestDelegate next)
//         {
//             _next = next;
//         }

//         public async Task Invoke(HttpContext context)
//         {
//             var watch = new Stopwatch();
//             watch.Start();

//             await _next(context);

//             context.Response.OnStarting(() =>
//                         {
//                             watch.Stop();
//                             var responseTimeForCompleteRequest = watch.ElapsedMilliseconds;
//                             context.Response.Headers[RESPONSE_HEADER_RESPONSE_TIME] = responseTimeForCompleteRequest.ToString();
//                             context.Response.Headers[RESPONSE_HEADER_APP_INSTANCE] = AppInstance.ToString();
//                             return Task.CompletedTask;
//                         });
//             // context.Response.Headers.Add("X-Processing-Time-Milliseconds", new[] { watch.ElapsedMilliseconds.ToString() });
//             // context.Response.Headers.Add("X-AppInstance", AppInstance);
//         }
//     }
// }