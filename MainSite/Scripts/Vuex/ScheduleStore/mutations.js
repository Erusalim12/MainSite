export default {
  SET_SCHEDULE_TO_LIST: (state, scheduleList) => {
    state.scheduleList = scheduleList;
  },

  SET_SELECTED_FACULTET:(state,selectedData)=>{
    state.selectedFacultet = selectedData;
  }
};
