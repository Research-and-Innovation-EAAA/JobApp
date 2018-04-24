
//using jobApp.Data;
using jobApp.Models;
using jobApp.Models.DBModels;
using JobApp.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobApp.DAL
{
    public class JobDBRepository : IJobDBRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public JobDBRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Region> AllRegions()
        {
            return _dbContext.Region.ToList();
        }

        public Annonce getAnnonce(uint id)
        {
            return _dbContext.Annonce.Find(id);
        }

        public IEnumerable<Kompetence> KompetenceByAnnonceID(long id)
        {
            IEnumerable<Kompetence> AKList = _dbContext.AnnonceKompetence.Where(x => x.AnnonceId == id).Select(z => z.Komptence);
            //IEnumerable<Kompetence> kList = AKList.Select(x => x.Komptence);


            return AKList.ToList();
        }
    }
}
