using Microsoft.AspNetCore.Mvc;
using CSIT_Project.Pages.Entities;
using Azure.Core;

namespace CSIT_Project.Pages.NewControllers
{
    public class ViewAllWorkSlotsController
    {
        public List<WorkSlot> viewAllWorkSlots()
        {
            return new WorkSlot().ViewWorkSlot();
        }

        public int GetMaxWeeksFromDatabase()
        {
            return new WorkSlot().GetMaxWeeks();
        }
    }

    public class ViewWorkSlotDetailsController
    {
        public WorkSlot viewWorkSlotDetails(string workRole, string startTime, string workDay, int workWeek)
        {
            WorkSlot workSlot = new WorkSlot();
            workSlot.setWorkRole(workRole);
            workSlot.setStartTime(startTime);
            workSlot.setWorkDay(workDay);
            workSlot.setWorkWeek(workWeek);
            workSlot = workSlot.viewWorkSlotDetails();

            return workSlot;
        }
    }

    public class ViewCafeStaffController
    {
        public List<UserAccount> viewStaff()
        {
            var staffList = new UserAccount().viewStaff();

            return staffList;
        }
    }

    public class ViewStaffTotalWorkSlotsController
    {
        public List<UserAccount> getTotalWorkSlots(List<UserAccount> list)
        {
            foreach (var staffMember in list)
            {
                staffMember.GetTotalWorkSlots();
            }

            return list;
        }
    }

    public class SearchCafeStaffController
    {
        public List<UserAccount> searchStaff(string search)
        {
            return new UserAccount().SearchStaff(search);
        }
    }

    public class ViewStaffBidController
    {
        public List<StaffBid> viewProcessingStaffBids()
        {
            StaffBid bid = new StaffBid();
            List<StaffBid> listStaffBids = bid.viewProcessingStaffBids();

            return listStaffBids;
        }

        public List<StaffBid> viewCompletedStaffBids()
        {
            StaffBid bid = new StaffBid();
            List<StaffBid> listStaffBids = bid.viewCompletedStaffBids();

            return listStaffBids;
        }
    }

    public class SearchWorkSlotController
    {
        public List<WorkSlot> SearchWorkSlot(string search)
        {
            return new WorkSlot().SearchWorkSlot(search);
        }
    }

    public class BidRejectionController
    {
        public void changeBidStatus(StaffBid staffBid, string newStatus)
        {
                staffBid.rejectBid();
        }

        public List<StaffBid> viewProcessingStaffBids()
        {
            StaffBid bid = new StaffBid();
            List<StaffBid> listStaffBids = bid.viewProcessingStaffBids();

            return listStaffBids;
        }
    }

    public class BidApprovalController
    {
        public void changeBidStatus(StaffBid staffBid, string newStatus)
        {
            staffBid.approveBid();
        }

        public List<StaffBid> viewProcessingStaffBids()
        {
            StaffBid bid = new StaffBid();
            List<StaffBid> listStaffBids = bid.viewProcessingStaffBids();

            return listStaffBids;
        }

        public void setStaffAllocated(WorkSlot workslot, int userAccountId)
        {
            workslot.setStaffAllocated(userAccountId);
        }

        public List<WorkSlot> viewAllWorkSlots()
        {
            return new WorkSlot().ViewWorkSlot();
        }
    }


}
