﻿using Nancy.Json;

namespace Nancy.Responses
{
    using System;
    using System.IO;

    public class JsonResponse<TModel> : Response
    {
        public JsonResponse(TModel model)
        {
            this.Contents = GetJsonContents(model);
            this.ContentType = "application/json";
            this.StatusCode = HttpStatusCode.OK;
        }
     
        private static Action<Stream> GetJsonContents(TModel model)
        {
            return stream =>
            {
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(model);

                var writer = new StreamWriter(stream);

                writer.Write(json);
                writer.Flush();
            };
        }
    }
}