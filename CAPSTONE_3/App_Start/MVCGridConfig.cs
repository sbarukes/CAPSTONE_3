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

            MVCGridDefinitionTable.Add("CoGrid", new MVCGridBuilder<Course>()
                .WithAuthorizationType(AuthorizationType.AllowAnonymous)
                .AddColumns(cols =>
                {
                    cols.Add().WithColumnName("CourseName")
                        .WithHeaderText("Course Name")
                        .WithValueExpression(i => i.CourseName); // use the Value Expression to return the cell text for this column
                    cols.Add().WithColumnName("CourseIns")
                        .WithHeaderText("Course Instructor")
                        .WithValueExpression(i => i.Instructor);
                    cols.Add().WithColumnName("Action")
                        .WithHeaderText("Action")
                        .WithValueExpression((i, c) => c.UrlHelper.Action("Add", "Home", new { cId = i.CourseId }))
                        .WithValueTemplate("<a href='{Value}'>Add</a>", false); ;
                })
                .WithRetrieveDataMethod((context) =>
                {
                    RegistrationRepository _r = new RegistrationRepository();
                    return new QueryResult<Course>()
                    {
                        Items = _r.Get(Globals.LoggedInUser).Courses,
                        TotalRecords = 0 // if paging is enabled, return the total number of records of all pages
                    };

                })
            );

            MVCGridDefinitionTable.Add("RegGrid", new MVCGridBuilder<Registration>()
                .WithAuthorizationType(AuthorizationType.AllowAnonymous)
                .AddColumns(cols =>
                {
                    cols.Add().WithColumnName("CourseName")
                        .WithHeaderText("Course Name")
                        .WithValueExpression(i => i.Course.CourseName); // use the Value Expression to return the cell text for this column
                    cols.Add().WithColumnName("InstructorName")
                        .WithHeaderText("Instructor")
                        .WithValueExpression(i => i.Course.Instructor);
                    cols.Add("Action").WithValueExpression((p, c) => c.UrlHelper.Action("Delete", "Home", new { regId = p.RegistrationId }))
                    .WithValueTemplate("<a href='{Value}'>Delete</a>", false);
                    //cols.Add().WithColumnName("InstructorName")
                    //    .WithHeaderText("Instructor")
                    //    .WithValueExpression(i => i.Course.Instructor);
                })
                .WithAdditionalQueryOptionNames("Search")
                .WithRetrieveDataMethod((context) =>
                {
                    var options = context.QueryOptions;
                    string globalSearch = options.GetAdditionalQueryOptionString("Search");
                    RegistrationRepository _r = new RegistrationRepository();
                    var items = _r.Get(Globals.LoggedInUser).Registrations;
                    if (!string.IsNullOrEmpty(globalSearch))
                    {
                        items = _r.Get(Globals.LoggedInUser).Registrations.Where(x => x.Course.CourseName.Contains(globalSearch) || x.Course.Instructor.Contains(globalSearch)).ToList();
                    }

                    return new QueryResult<Registration>()
                    {
                        Items = items,
                        TotalRecords = 0 // if paging is enabled, return the total number of records of all pages
                    };

                })
            );

            MVCGridDefinitionTable.Add("ReportGrid", new MVCGridBuilder<CourseInstructorCount>()
                .WithAuthorizationType(AuthorizationType.AllowAnonymous)
                .AddColumns(cols =>
                {
                    cols.Add().WithColumnName("CourseIns")
                        .WithHeaderText("Instructor")
                        .WithValueExpression(i => i.Instructor); // use the Value Expression to return the cell text for this column
                    cols.Add().WithColumnName("CourseCount")
                        .WithHeaderText("Course Count")
                        .WithValueExpression(i => i.Count.ToString());
                })
                .WithRetrieveDataMethod((context) =>
                {
                    CourseRepository _c = new CourseRepository();
                    var courses = _c.CountCourses();
                    return new QueryResult<CourseInstructorCount>()
                    {
                        Items = courses,
                        TotalRecords = 0 // if paging is enabled, return the total number of records of all pages
                    };

                })
            );

        }
    }
}