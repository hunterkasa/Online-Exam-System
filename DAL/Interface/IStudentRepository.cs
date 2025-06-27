﻿using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IStudentRepository : IRepository<Student>
    {
        Student GetByEmail(string email);
    }
}
