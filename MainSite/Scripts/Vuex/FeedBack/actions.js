import axios from "axios";

export default {
  async GET_MESSAGE_INFO({ commit }) {
    try {
      let result = await axios("/api/Question/newMessage", {
        method: "get",
      });
      if (result.data) commit("SET_MESSAGE", result.data.result);
    } catch (ex) {}
  },
};
