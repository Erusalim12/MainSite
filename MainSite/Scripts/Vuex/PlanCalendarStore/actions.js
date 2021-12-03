import axios from "axios";

export default {
  async GET_PLAN_CALENDAR({ commit }) {
    try {
      let result = await axios("/api/ApiPlanCalendar/getPlanCalendar", {
        method: "get",
      });

      if (result.data) {
        let model = result.data.reduce((newObj, event) => {
          let newEvent = Object.keys(event).reduce((res, key) => {
            if (key !== "date" && key !== "day") res[key] = event[key];
            return res;
          }, {});

          if (!Object.keys(newObj).includes(event.day)) {
            newObj[event.day] = {
              events: [newEvent],
              date: event.date,
            };
          } else {
            newObj[event.day].events.push(newEvent);
          }

          return newObj;
        }, {});

        commit("SET_PLAN_CALENDAR", model);
      }
    } catch (ex) {}
  },
};
