 <template>
 <div class="ms-schedule-menu">
    <!-- <a href="#">Традиционное</a> -->
    <a href="#">Для курсантов и командиров</a>
    <!-- <a href="#">Для преподавателей</a>
    <a href="#">Для лаборантов</a>
    <a href="#">Для управления</a> -->
    <ms-schedule-accordeon/>


 
    <div
      class="card_birthday-content_description"
      v-for="item in list"
      :key="item.id"
    >
      <span class="fio">{{ item.fio }}</span>
      <span class="subdivision">{{ getSubDivision(item) }}</span>
    </div>



  </div>
</template>

<script>
 import msScheduleAccordeon from './ms-schedule-accordeon.vue' 
export default {
  name: "ms-schedule-menu",
  components: {
    msScheduleAccordeon,
  },
};
</script>

<style lang="scss">
.ms-schedule-menu {
  width: 25%;
  position: absolute;
  right: 0;
  top: 0;
  margin: 0;
  transform: translateX(110%);

  @media (max-width: 992px) {
    margin: 0.5rem 0 1rem 0;
    transform: translateX(0px);
    position: inherit;
    width: 100%;
  }

  @media only screen and (min-width: 993px) and (max-width: 1700px) {
    width: 34%;
  }
}
 
</style>

</style>
