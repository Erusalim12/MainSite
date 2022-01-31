<template>
  <div class="ms-schedule "> 
    <h6 class="ms-schedule-header">{{ GET_SCHEDULE.header }}</h6>
  
      <ms-schedule-daily
        v-for="daily in GET_SCHEDULE.day"
        :key="daily.date"
        :dailyRasp="daily"
       
      /> 
    <ms-schedule-menu />
  </div>
</template>

<script>
import MsScheduleMenu from "./ms-schedule-menu.vue";
import MsScheduleDaily from "./ms-schedule-daily.vue";
import { mapActions, mapGetters, mapMutations } from "vuex";

export default {
  name: "ms-schedule",
  components: {
    //список дочерних компонентов
    MsScheduleMenu,
    MsScheduleDaily,
  },
  props: {
    //неперсональные данные компонента - те что приходят из родителя
  },
  data() {
    //персональные данные компонента
    return {};
  },
  computed: {
    //вычисляемые данные компонента
    ...mapGetters("schedule", ["GET_SCHEDULE"]),
  },
  methods: {
    //методы, обработчики событий
    ...mapActions("schedule", ["GET_SCHEDULE_FROM_API"]),
  },

  mounted() {
    // срабатывает при полной загрузке компонента
  },
};
</script>

<style>
.ms-schedule {
  position: relative;
   display: flex;
    max-width: 900px;
    margin: 0 auto;
    flex-direction: row;
    justify-content: space-evenly;
    font-size: 12;
    flex-wrap: wrap;
    align-content: stretch;
    align-items: stretch;

}
</style>
