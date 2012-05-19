using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WSStat.Repository;
using WSStat.Common.Logging;
using WSStat.Model;

namespace WSStat.Controllers
{
    public class DataServiceController : Controller
    {
        private IEquipmentRepository equipmentRepository;
        private ISailingSessionsRepository sailingSessionsRepository;
        private ILogger logger;

        public DataServiceController
            (IEquipmentRepository equipmentRepository, 
             ISailingSessionsRepository sailingSessionsRepository,
             ILogger logger)
        {
            this.equipmentRepository = equipmentRepository;
            this.sailingSessionsRepository = sailingSessionsRepository;
            this.logger = logger;
        }

        public ActionResult GetSailingSession(int sailorId)
        {
            ICollection<SailingSession> sessions = sailingSessionsRepository.GetSailingSessions(sailorId);
            return Json(sessions, JsonRequestBehavior.AllowGet);
        }
    }
}
