using Data.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Text;
using WebBuilder.Business.Abstract.DataServices;

namespace WebBuilder.Business.Concrete
{
    public class ProjectMenager: DataService<Project, IProjectDAL>, IProjectService
    {
        private readonly IProjectDAL projectDAL;
        public ProjectMenager(IProjectDAL projectDAL) : base(projectDAL)
        {
            this.projectDAL = projectDAL;
        }
    }
}
