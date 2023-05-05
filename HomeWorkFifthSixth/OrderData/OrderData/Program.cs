using Microsoft.Extensions.Configuration;
using OrderData.ADO;
using OrderData.EF;
using OrderData.Models;

var builder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", true, true);
var config = builder.Build();
var connectionString = config["ConnectionStrings:DefaultConnection"];

OrderDataADO orderADO = new OrderDataADO(connectionString);
var orders = orderADO.GetOrdersFromLastYearSQLAdapter();

Order newOrder = new()
{
    Id = 9,
    Date = DateTime.Now,
    AnalysisId = 6
};

var createRes = orderADO.CreateOrder(newOrder);

Order orderToUpdate = new()
{
    Id = 9,
    Date = DateTime.Now,
    AnalysisId = 4
};

var updateRes = orderADO.UpdateOrder(orderToUpdate);

var deleteRes = orderADO.DeleteOrder(9);

OrderDataEF orderDataEF = new OrderDataEF(connectionString);

var res = await orderDataEF.GetOrdersFromLastYear();

var addedOrder = await orderDataEF.AddOrder(newOrder);

await orderDataEF.UpdateOrder(orderToUpdate);

await orderDataEF.DeleteOrder(orderToUpdate);
