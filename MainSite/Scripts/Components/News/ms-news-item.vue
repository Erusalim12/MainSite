﻿<template>
  <div class="card-panel detailsNew" :id="GetUnicIdBlock">
    <template v-if="!isEditer">
      <div class="card_news card_news-details">
        <div class="card_news-image">
          <img :src="this.news_item.urlIcon" alt="" />
        </div>
        <div class="card_news-main">
          <div v-if="isNews" class="card_news-main-header">
            <span class="bold">{{ this.news_item.lastChangeAutor }}</span>
            <span class="bold">{{ this.IsChangeNews }} запись в разделе</span>
            <router-link
              :id="news_item.id"
              :to="{
                name: 'categoryDetails',
                params: { categoryId: news_item.categoryId, page: 1 },
              }"
            >
              {{ this.news_item.category }}
            </router-link>
          </div>
          <div class="card_news-main-title">
            <a>{{ this.news_item.header }}</a>
          </div>
          <div class="card_news-main-footer">
            <b v-if="!isNews">{{ this.news_item.lastChangeAutor }}</b>
            {{ RefactDate }}
          </div>
        </div>

        <div class="card_news-editor">
          <a
            href="#"
            v-on:click.prevent="changeSectionEditer"
            title="Редактировать"
            ><i class="material-icons">edit</i></a
          >
          <a
            href="#"
            class="error"
            v-on:click.prevent="deleteNews"
            title="Удалить"
            ><i class="material-icons">close</i></a
          >
        </div>
      </div>

      <div
        class="card_news-description"
        v-html="this.news_item.description"
      ></div>

      <ul class="dropdownFiles">
        <li v-for="item in news_item.files" :key="item.id">
          <a :href="hrefFile(item.id)"
            ><img
              src="/images/layout_icons/News/fileLoad.svg"
              style="padding-right: 5px"
            />
            {{ item.name }}</a
          >
        </li>
      </ul>
    </template>
    <template v-else>
      <div>
        <div class="card_news-editor" style="right: 10px">
          <a href="#" v-on:click.prevent="changeSectionEditer" title="Назад"
            ><i class="material-icons">reply</i></a
          >
        </div>
        <msChangeNewsForm
          :isAdvancedEditor="news_item.isAdvancedEditor"
          :categoryId="news_item.categoryId"
          @changeNew="changeNew"
          :editModel="news_item"
          :editFiles="news_item.files"
          textSubmit="Редактировать"
        />
      </div>
    </template>
  </div>
</template>

<script>
import msChangeNewsForm from "./ms-change_news-form.vue";
import { mapActions } from "vuex";
import msSimpleModal from "../../DefaultComponents/Modal/templates/ms-simple-modal";
import msImageModal from "../../DefaultComponents/Modal/templates/ms-image-modal";
import {
  ImageCalendarService,
  ImageGlobalService,
} from "../../Services/ImageModalService.js";
export default {
  name: "ms-news-item",
  props: {
    news_item: {
      type: Object,
      default: () => {
        return {};
      },
    },
    isNews: {
      type: Boolean,
      default: () => {
        return true;
      },
    },
    index: {
      type: Number,
      default: () => {
        return null;
      },
    },
  },
  data: () => {
    return {
      isEditer: false,
      modalOptionsDelete: {
        body: "Это действие невозможно будет отменить, и все приложенные изображения и другие ресурсы так же будут удалены. Удалить запись?",
        header: "Вы действительно хотите удалить запись?",
      },
      imageService: new ImageCalendarService(),
    };
  },
  components: {
    msChangeNewsForm,
  },
  computed: {
    IsChangeNews() {
      return this.news_item.lastChangeDate !== this.news_item.createdDate
        ? "отредактировал(а)"
        : "разместил(а)";
    },
    GetUnicIdBlock() {
      return "new_" + this.news_item.id;
    },
    RefactDate() {
      let options = {
        day: "numeric",
        month: "long",
        year: "numeric",
      };

      const curDate =
        new Date(this.news_item.lastChangeDate).getFullYear() != 1
          ? this.news_item.lastChangeDate
          : this.news_item.createdDate;

      let date = new Date(curDate);
      let formatDate = date.toLocaleDateString("ru", options).replace("г.", "");
      let minutes =
        date.getMinutes() < 10 ? `0${date.getMinutes()}` : date.getMinutes();
      let formatTime = `${date.getHours()}:${minutes}`;

      return `${formatDate} в ${formatTime}`;
    },
  },
  methods: {
    ...mapActions("news", ["UPDATE_NEW", "DELETE_NEW"]),
    ...mapActions("user", ["GET_PERMISSION_BY_CATEGORY"]),
    hrefFile(id) {
      return `/GetFile?fileId=${id}`;
    },
    async changeSectionEditer() {
      if (await this.getInfoByPermission()) {
        this.isEditer = !this.isEditer;
      } else {
        M.toast({ html: "Нет прав на редактирование данной записи!" });
      }
    },
    async deleteNews() {
      if (await this.getInfoByPermission()) {
        let vm = this;

        this.$modals.open({
          title: this.modalOptionsDelete.header,
          bodyInfo: this.modalOptionsDelete.body,
          component: msSimpleModal,
          onClose(data) {
            if (data.ended) return false;
            vm.DELETE_NEW({ index: vm.index, id: vm.news_item.id });
          },
        });
      } else {
        M.toast({ html: "Нет прав на удаление данной записи!" });
      }
    },
    async changeNew(result) {
      let res = await this.UPDATE_NEW({ data: result });
      if (res) {
        await this.changeSectionEditer();
      }
    },
    async getInfoByPermission() {
      return await this.GET_PERMISSION_BY_CATEGORY(this.news_item.categoryId);
    },
    showImageSlider() {
      let vm = this;

      function showModal() {
        vm.imageService.setCurrentItemId(this.getAttribute("id"));
        let currentImg = this;
        ImageGlobalService.setCurrentImageCalendarService(vm.imageService);
        vm.$modals.open({
          component: msImageModal,
          className: "vu-modal__cmp--is-img-slider",
          bodyPadding: false,
          center: true,
          onClose: () => {
            currentImg.removeEventListener("click", showModal);
          },
        });
      }

      for (var item of document.querySelectorAll(
        `#${this.GetUnicIdBlock} .card_news-description img`
      )) {
        vm.imageService.addItem({
          id: item.getAttribute("id"),
          src: item.getAttribute("src"),
        });
        item.style.cursor = "pointer";
        item.addEventListener("click", showModal);
      }
    },
  },
  mounted() {
    this.showImageSlider();
  },
  updated() {
    this.imageService = new ImageCalendarService();
    this.showImageSlider();
  },
};
</script>

<style scoped lang="scss">
.detailsNew {
  position: relative;
}
.card_news-description {
  font-size: 14px;
  overflow: hidden;

  img {
    object-fit: cover;
  }
}
.dropdownFiles a {
  display: inline-flex;
  align-items: center;
  padding-bottom: 5px;
  font-size: 14px;
  & > img {
    width: 23px;
  }
  &:hover {
    color: #64b5f6 !important;
  }
}
</style>
