﻿using jobApp.Models;
using jobApp.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobApp.BLL
{
    public interface IJobDBRepository
    {
        IEnumerable<Region> AllRegions();
        IEnumerable<Kompetence> KompetenceByAnnonceID(long id);
        Annonce getAnnonce(uint id);
    }
}
