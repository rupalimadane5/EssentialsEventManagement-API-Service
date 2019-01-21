using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using Models.EMS.Entity;

namespace DataLayer.EMS.Repository
{
    public class EMSRepository : IEMSRepository
    {
        AmazonDynamoDBConfig clientConfig;
        AmazonDynamoDBClient client;

        public EMSRepository()
        {
            clientConfig = new AmazonDynamoDBConfig();
            clientConfig.RegionEndpoint = RegionEndpoint.USWest2;
            client = new AmazonDynamoDBClient(
                awsAccessKeyId: "AKIAJUIVEFNPQPOKCEEA",
                awsSecretAccessKey: "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",
                clientConfig: clientConfig);
        }

        public EventEntity CreateEvent(EventEntity entity)
        {
            try
            {
                var request = new PutItemRequest()
                {
                    TableName = "Events", // Need to correct Table Name to the AWS console - DynamoDB - Table
                    Item = new Dictionary<string, AttributeValue>()
                {
                         {
                        "EventId",
                        new AttributeValue
                         {
                            S=string.IsNullOrEmpty( entity.pkEvent)? Guid.NewGuid().ToString() :entity.pkEvent
                         }
                    },
                    {
                        "EventName",
                        new AttributeValue
                        {
                            S=entity.sEventName
                        }
                    },
                    {
                        "EventDate" ,
                        new AttributeValue()
                        {
                            S=entity.sEventDate
                        }
                    },
                     {
                        "EventTime" ,
                        new AttributeValue()
                        {
                            S=entity.sEventTime
                        }
                    },
                     {
                        "EventColor" ,
                        new AttributeValue()
                        {
                            S=entity.sEventColor
                        }
                    }
                }
                };
                var response = client.PutItemAsync(request);
                return entity;
            }
            catch (Exception ex)
            {
                //Console.WriteLine($"Error occured while saving data : ", ex.Message);
                throw ex;
            }
        }

        public List<EventEntity> GetEventDetails(string fromDate, string toDate)
        {
            string tableName = "Events";
            Table appointmentRequestTable = Table.LoadTable(client, tableName);

            Dictionary<string, Condition> conditions = new Dictionary<string, Condition>();
            Condition dateCondition = new Condition();

            dateCondition.ComparisonOperator = ComparisonOperator.BETWEEN;
            dateCondition.AttributeValueList.Add(new AttributeValue { S = fromDate });
            dateCondition.AttributeValueList.Add(new AttributeValue { S = toDate });
            conditions["EventDate"] = dateCondition;

            ScanRequest request = new ScanRequest
            {
                TableName = tableName,
                ScanFilter = conditions
            };

            var response = client.ScanAsync(request);
            return new List<EventEntity>();
        }
    }
}
