import axios from "axios";

export default {
    async  GET_SCHEDULE_FROM_API({commit},data){
    //  store.rootState.preLoader.isActive = true;
    
        return  await  axios('/Rasp/ForCursants/',{
            method:"GET",
            params:{
                facultetNum: data.Facultet,
                courseNum:data.Cource,
                addWeeks :data.addWeeks
            }
        })
        .then((scheduleList)=>{
             commit('SET_SCHEDULE_TO_LIST',scheduleList.data)
            return  scheduleList.data;
        })
        .catch((err)=>{
            console.log(err);
            return err;
        })
        // store.rootState.preLoader.isActive = false;
    }
}