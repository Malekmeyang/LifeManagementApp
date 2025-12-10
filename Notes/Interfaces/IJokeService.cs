using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Interfaces
{
    public interface IJokeService
    {
        Task<string> GetDailyJokeAsync();
    }
}