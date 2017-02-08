using Nancy;
using Todo.Objects;
using System.Collections.Generic;

namespace ToDoList
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        return View["index.cshtml"];
      };
      Get["/tasks"] = _ => {
        List<Task> allTasks = Task.GetAll();
        return View["task.cshtml"];
      };
      Get["/tasks/new"] = _ => {
        return View["task_form.cshtml"];
      };
      Get["/task/{id}"] = parameters => {
        Task task = Task.Find(parameters.id);
        return View["task.cshtml", task];
      };
      Post["/tasks"] = _ => {
        Task newTask = new Task(Request.Form["new-task"]);
        List<Task> allTasks = Task.GetAll();
        return View["tasks.cshtml", allTasks];
      };
    }
  }
}