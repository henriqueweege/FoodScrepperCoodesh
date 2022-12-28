using FluentScheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodScrapper.Infrastructure.TaskHandler
{
    public class TaskRegisterer : Registry
    {
        public TaskRegisterer()
        {
            Schedule<ScrapperTriggerer>().ToRunEvery(1).Days();
        }
    }

    
}
