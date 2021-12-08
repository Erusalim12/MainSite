import axios from "axios";

export default {
  async GET_INFO_BY_CURRENT_USER({ commit }) {
    try {
      try {
        let result = await axios("/api/ApiUsers/InfoCurrentUser", {
          method: "GET",
        });
        commit("SET_USER", result.data);
      } catch (ex) {}
    } catch (ex) {}
  },
  async GET_PERMISSION_BY_CATEGORY({ commit }, categoryId) {
    try {
      let result = await axios("/api/ApiUsers/IsPermission", {
        method: "GET",
        params: { categoryId: categoryId },
      });

      return result.data;
    } catch (ex) {}
  },
  async GET_BIRTHDAYS({ commit }) {
    try {
      let result = await axios("/api/ApiUsers/GetBirthdayUsers", {
        method: "GET",
      });

      if (result.data) commit("SET_BIRTHDAYS", result.data);
    } catch (ex) {}
  },
};
