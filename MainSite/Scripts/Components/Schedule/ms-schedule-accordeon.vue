<template>
  <div class="ms-schedule-accordeon">
    <ul class="collapsible">
      <li v-for="Facultet in facultets" :key="Facultet.Name">
        <div class="collapsible-header btn btn-default">
          {{ Facultet.Name }}
        </div>
        <div class="collapsible-body">
          <div v-for="cource in Facultet.Cources" :key="cource.Name">
            <button class="btn btn-default" v-on:click="loaddata(cource.Value)">
              {{ cource.Name }}
            </button>
          </div>
        </div>
      </li>
    </ul>
  </div>
</template>


<script>
import M from "../../../wwwroot/css/materialize/js/materialize";
import { mapActions, mapState, mapMutations } from "vuex";
export default {
  name: "ms-schedule-accordeon",
  data() {
    return {
      facultets: [
        {
          Name: "1 Факультет (АСУ)",
          Cources: [
            { Name: "1 Курс 1 факультета", Value: { Facultet: 1, Cource: 1 } },
            { Name: "2 Курс 1 факультета", Value: { Facultet: 1, Cource: 2 } },
            { Name: "3 Курс 1 факультета", Value: { Facultet: 1, Cource: 3 } },
            { Name: "4 Курс 1 факультета", Value: { Facultet: 1, Cource: 4 } },
            { Name: "5 Курс 1 факультета", Value: { Facultet: 1, Cource: 5 } },
          ],
        },
        {
          Name: "2 Факультет (ЗРК)",
          Cources: [
            { Name: "1 Курс 2 факультета", Value: { Facultet: 2, Cource: 1 } },
            { Name: "2 Курс 2 факультета", Value: { Facultet: 2, Cource: 2 } },
            { Name: "3 Курс 2 факультета", Value: { Facultet: 2, Cource: 3 } },
            { Name: "4 Курс 2 факультета", Value: { Facultet: 2, Cource: 4 } },
            { Name: "5 Курс 2 факультета", Value: { Facultet: 2, Cource: 5 } },
          ],
        },
        {
          Name: "3 Факультет (КП ЗРС)",
          Cources: [
            { Name: "1 Курс 3 факультета", Value: { Facultet: 3, Cource: 1 } },
            { Name: "2 Курс 3 факультета", Value: { Facultet: 3, Cource: 2 } },
            { Name: "3 Курс 3 факультета", Value: { Facultet: 3, Cource: 3 } },
            { Name: "4 Курс 3 факультета", Value: { Facultet: 3, Cource: 4 } },
            { Name: "5 Курс 3 факультета", Value: { Facultet: 3, Cource: 5 } },
          ],
        },
        {
          Name: "4 Факультет (СтЭО)",
          Cources: [
            { Name: "1 Курс 4 факультета", Value: { Facultet: 4, Cource: 1 } },
            { Name: "2 Курс 4 факультета", Value: { Facultet: 4, Cource: 2 } },
            { Name: "3 Курс 4 факультета", Value: { Facultet: 4, Cource: 3 } },
            { Name: "4 Курс 4 факультета", Value: { Facultet: 4, Cource: 4 } },
            { Name: "5 Курс 4 факультета", Value: { Facultet: 4, Cource: 5 } },
          ],
        },
        {
          Name: "5 Факультет (РЛК)",
          Cources: [
            { Name: "1 Курс 5 факультета", Value: { Facultet: 5, Cource: 1 } },
            { Name: "2 Курс 5 факультета", Value: { Facultet: 5, Cource: 2 } },
            { Name: "3 Курс 5 факультета", Value: { Facultet: 5, Cource: 3 } },
            { Name: "4 Курс 5 факультета", Value: { Facultet: 5, Cource: 4 } },
            { Name: "5 Курс 5 факультета", Value: { Facultet: 5, Cource: 5 } },
          ],
        },
        {
          Name: "6 Факультет (РЛС МВ)",
          Cources: [
            { Name: "1 Курс 6 факультета", Value: { Facultet: 6, Cource: 1 } },
            { Name: "2 Курс 6 факультета", Value: { Facultet: 6, Cource: 2 } },
            { Name: "3 Курс 6 факультета", Value: { Facultet: 6, Cource: 3 } },
            { Name: "4 Курс 6 факультета", Value: { Facultet: 6, Cource: 4 } },
            { Name: "5 Курс 6 факультета", Value: { Facultet: 6, Cource: 5 } },
          ],
        },
        {
          Name: "7 Факультет (РТС ОПА)",
          Cources: [
            { Name: "1 Курс 7 факультета", Value: { Facultet: 7, Cource: 1 } },
            { Name: "2 Курс 7 факультета", Value: { Facultet: 7, Cource: 2 } },
            { Name: "3 Курс 7 факультета", Value: { Facultet: 7, Cource: 3 } },
            { Name: "4 Курс 7 факультета", Value: { Facultet: 7, Cource: 4 } },
            { Name: "5 Курс 7 факультета", Value: { Facultet: 7, Cource: 5 } },
          ],
        },
        {
          Name: "9 Факультет (Специальный)",
          Cources: [
            { Name: "0 Курс 9 факультета", Value: { Facultet: 9, Cource: 0 } },
            { Name: "1 Курс 9 факультета", Value: { Facultet: 9, Cource: 1 } },
            { Name: "2 Курс 9 факультета", Value: { Facultet: 9, Cource: 2 } },
            { Name: "3 Курс 9 факультета", Value: { Facultet: 9, Cource: 3 } },
            { Name: "4 Курс 9 факультета", Value: { Facultet: 9, Cource: 4 } },
            { Name: "5 Курс 9 факультета", Value: { Facultet: 9, Cource: 5 } },
          ],
        },
      ],
    };
  },

  computed:{           
... mapState('schedule',['selectedFacultet']),
  },

  methods: {
     ...mapActions("schedule", ["GET_SELECTED_FACULTET"]),
        //  ...mapMutations("schedule",['SET_SELECTED_FACULTET']),
    loaddata:function(values){//получили значение факультета и курса, передать расписанию
       this.GET_SELECTED_FACULTET(values);
      console.log("Cource: "+ values.Cource + " Facultet: "+ values.Facultet);
    }
  },
  mutations:{

    
  },


  mounted() {
    //действие при полной загрузке элемента
    M.AutoInit(); //инициализация всех элементов
  },
};
</script>

<style>
.collapsible.header {
  padding: 0px;
}
.collapsible-body {
  padding: 0px;
}
</style>