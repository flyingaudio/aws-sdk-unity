/*
 * Copyright 2014-2014 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *
 *
 * Licensed under the AWS Mobile SDK for Unity Developer Preview License Agreement (the "License").
 * You may not use this file except in compliance with the License.
 * A copy of the License is located in the "license" file accompanying this file.
 * See the License for the specific language governing permissions and limitations under the License.
 *
 */
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml.Serialization;

using Amazon.CognitoIdentity.Model;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.Runtime.Internal.Util;
using ThirdParty.Json.LitJson;

namespace Amazon.CognitoIdentity.Model.Internal.MarshallTransformations
{
    /// <summary>
    /// UnlinkIdentity Request Marshaller
    /// </summary>       
    public class UnlinkIdentityRequestMarshaller : IMarshaller<IRequest, UnlinkIdentityRequest> 
    {
        public IRequest Marshall(UnlinkIdentityRequest publicRequest)
        {
            IRequest request = new DefaultRequest(publicRequest, "Amazon.CognitoIdentity");
            string target = "AWSCognitoIdentityService.UnlinkIdentity";
            request.Headers["X-Amz-Target"] = target;
            request.Headers["Content-Type"] = "application/x-amz-json-1.1";
            request.HttpMethod = "POST";

            string uriResourcePath = "/";
            request.ResourcePath = uriResourcePath;
            using (StringWriter stringWriter = new StringWriter(CultureInfo.InvariantCulture))
            {
                JsonWriter writer = new JsonWriter(stringWriter);
                writer.WriteObjectStart();
                if(publicRequest.IsSetIdentityId())
                {
                    writer.WritePropertyName("IdentityId");
                    writer.Write(publicRequest.IdentityId);
                }

                if(publicRequest.IsSetLogins())
                {
                    writer.WritePropertyName("Logins");
                    writer.WriteObjectStart();
                    foreach (var publicRequestLoginsKvp in publicRequest.Logins)
                    {
                        writer.WritePropertyName(publicRequestLoginsKvp.Key);
                        var publicRequestLoginsValue = publicRequestLoginsKvp.Value;

                        writer.Write(publicRequestLoginsValue);
                    }
                    writer.WriteObjectEnd();
                }

                if(publicRequest.IsSetLoginsToRemove())
                {
                    writer.WritePropertyName("LoginsToRemove");
                    writer.WriteArrayStart();
                    foreach(var publicRequestLoginsToRemoveListValue in publicRequest.LoginsToRemove)
                    {
                        writer.Write(publicRequestLoginsToRemoveListValue);
                    }
                    writer.WriteArrayEnd();
                }

        
                writer.WriteObjectEnd();
                string snippet = stringWriter.ToString();
                request.Content = System.Text.Encoding.UTF8.GetBytes(snippet);
            }


            return request;
        }


    }
}