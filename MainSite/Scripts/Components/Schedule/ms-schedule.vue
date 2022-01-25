<template>
  <div class="ms-schedule" style="position: relative">
    <p>Расписание курсантов</p>

    <ms-schedule-daily
      v-for="daily in rasp"
      :key="daily.day"
      :dailyRasp="daily"
      @sendDataToParent="showchildValInconsole"
    />
    {{updateResults}}
    <ms-schedule-menu />
  </div>
</template>

<script>
import MsScheduleMenu from "./ms-schedule-menu.vue";
import MsScheduleDaily from "./ms-schedule-daily.vue";
import { mapActions,mapGetters, mapMutations } from "vuex";

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
      rasp :{};
    //персональные данные компонента
    return {};
  },
  computed: {
    //вычисляемые данные компонента
      ...mapGetters("schedule",['GET_SCHEDULE']),
      
   

  },
  methods: {
    //методы, обработчики событий
      ...mapActions("schedule", ["GET_SCHEDULE_FROM_API"]),
      ...mapMutations("schedule",['SET_SELECTED_FACULTET'])

    ,
      updateResults: function(){
       this.rasp = this.GET_SCHEDULE;
     }
  },
 
  mounted() {
   // this.GET_SCHEDULE_FROM_API();
  },
};
</script>

<style scoped lang="scss">
.ms-schedule {
  display: flex;
  justify-content: center;
  align-items: center;
  max-width: 900px;
  margin: 0 auto;
  flex-direction: column;
}
</style>
