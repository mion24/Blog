﻿using Blog.Core.Contexts.SharedContext.UseCases;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Contexts.AccountContext.UseCases.Create
{
    public class Response : SharedContext.UseCases.Response
    {
        protected Response()
        {
        }

        public Response(string message, int status, IEnumerable<Notification>? notifications = null)
        {
            Message = message;
            Status = status;
            Notifications = notifications;
        }

        public Response(string message, ResponseData data)
        {
            Message = message;
            Status = 201;
            Notifications = null;
            Data = data;
        }

        public ResponseData? Data { get; set; }
    }

    public record ResponseData(Guid id, string name, string email);
}

