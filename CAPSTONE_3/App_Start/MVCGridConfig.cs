[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(CAPSTONE_3.MVCGridConfig), "RegisterGrids")]

namespace CAPSTONE_3
{
    using System;
    using System.Web;
    using System.Web.Mvc;
    using System.Linq;
    using System.Collections.Generic;
    using CAPSTONE_3.Controllers;
    using MVCGrid.Models;
    using MVCGrid.Web;
    using CAPSTONE_3.Models;
    using CAPSTONE_3.Repositories;

    public static class MVCGridConfig 
    {
        public static void RegisterGrids()
        {

            MVCGridDefinitionTable.Add("UsageExample", new MVCGridBuilder<Course>()
                .WithAuthorizationType(AuthorizationType.AllowAnonymous)
                .AddColumns(cols =>
                {
                    cols.Add().WithColumnName("UniqueColumnName")
                        .WithHeaderText("Any Header")
                        .WithValueExpression(i => i.CourseName); // use the Value Expression to return the cell text for this column
                    cols.Add().WithColumnName("UrlExample")
                        .WithHeaderText("Edit")
                        .WithValueExpression((i, c) => c.UrlHelper.Action("detail", "demo", new { id = i.CourseId }));
                })
                .WithRetrieveDataMethod((context) =>
                {
                    RegistrationRepository _r = new RegistrationRepository();
                    return new QueryResult<Course>()
                    {
                        Items = _r.Get((Student)HttpContext.Current.Session["currentUser"]).Courses,
                        TotalRecords = 0 // if paging is enabled, return the total number of records of all pages
                    };

                })
            );

        }
    }
}