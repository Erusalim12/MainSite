import axios from 'axios';

export default {
  async GET_EXTERNAL_LINKS({ commit }) {
    try {
      let result = await axios('/api/ApiExternalLinks/links/', {
        method: 'get',
      });
      commit('SET_LINKS', result.data);
    } catch (ex) {}
  },
};
