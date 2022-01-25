import axios from "axios";

export default {
     GET_SCHEDULE_FROM_API(store){
     store.rootState.preLoader.isActive = true;
     data = state.selectedFacultet;
     console.log("data",data);
        return   axios('/Rasp/ForCursants/',{
            method:"GET",
            params:{
                facultetNum: data.Facultet,
                courseNum:data.Cource,
                addWeeks :data.addWeeks
            }
        })
        .then((scheduleList)=>{
            commit('SET_SCHEDULE_TO_LIST',scheduleList)
            return  scheduleList;
        })
        .catch((err)=>{
            console.log(err);
            return err;
        })
        store.rootState.preLoader.isActive = false;
    },


    GET_SELECTED_FACULTET({commit} ,data){
        commit("SET_SELECTED_FACULTET", data);
 
        return data;
    }


}