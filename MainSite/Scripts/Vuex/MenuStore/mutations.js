export default {
  SET_CATEGORIES: (state, categories) => {
    state.categories = categories;
  },
  SET_BREADCRUMBS: (state, breadcrumbs) => {
    state.breadcrumbs = breadcrumbs;
  },
  ADD_BREADCRUMBS: (state, item) => {
    state.breadcrumbs.push(item);
  },
  SET_OR_UPDATE_ACTIVE_CATEGORY: (state, categoryId) => {
    if (categoryId !== state.activeCategoryId) state.activeCategoryId = categoryId;
  },
  ADD_CATEGORY: (state, category) => {
    function searchParentCategory(array, searchId) {
      array.forEach((element) => {
        if (element != null) {
          if (element.Id === searchId) {
            console.log(element);
            element.Children.push(category);
            return;
          } else {
            if (element.Children !== []) searchParentCategory(element.Children, searchId);
          }
        }
      });
    }

    searchParentCategory(state.categories, category.ParentId);
  },
};
