﻿<template>
    <li>
        <a href="javascript:void(0)"
           :title="menu_item.toolTip"
           v-bind:class="activeClass[IsActive]"
           @click="eventClickElementMenu(arguments[0])">
           <img v-if="GetPathImg" v-bind:src="GetPathImg" />
           <span v-else></span>
           <div>{{menu_item.Name}}</div>
        </a>

        <!--<ul
        v-if="menu_item.children && menu_item.children.length"
        >
        <ms-menu-item v-for="item in menu_item.children"
                      :key="item.id"
                      :menu_item="item"
                      >

        </ms-menu-item>
    </ul>-->
    </li>
</template>
<script>
    //import { ItemMenuActive } from '../../Filters/Menu'
    import { mapState, mapMutations } from 'vuex'

    export default {
        name: "ms-menu-item",
        props: {
            menu_item: {
                type: Object,
                default: () => { return {} }
            }
        },
        data:() => {
            return {
                activeClass: {
                    true: 'active',
                    false: ''
                }
            }
        },
        computed: {
            ...mapState('menu',[
                'activeCategoryId',
                'breadcrumbs'
            ]),
            GetPathImg() {
                return this.menu_item.UrlIcon;
            },
            IsActive() {
                if (this.$route.params.categoryId != undefined && this.$route.params.categoryId != this.menu_item.Id) {
                    if (this.breadcrumbs.length) {
                        return this.breadcrumbs[0].id == this.menu_item.Id ? true : false;
                    }
                }

                return this.menu_item.Id == this.activeCategoryId || this.$route.params.categoryId == this.menu_item.Id ? true : false;
            }
        },
        methods: {
            ...mapMutations('menu',[
                'SET_OR_UPDATE_ACTIVE_CATEGORY'
            ]),
            eventClickElementMenu(e) { 
                if (!this.IsActive) {
                    this.SET_OR_UPDATE_ACTIVE_CATEGORY(this.menu_item.Id);

                    if (this.menu_item.Children && this.menu_item.Children.length) {
                        this.$router.push({ name: "categoryList", params: { categoryId: this.menu_item.Id, category: this.menu_item } });
                    }
                    else {
                        this.$router.push({ name: "categoryDetails", params: { categoryId: this.menu_item.Id, page: 1 } });
                    }
                }
            },
        }
    };
</script>

<style scoped lang="scss">
    span {
        background-color: black;
        height: 2px;
        width: 30px;
    }
</style>