<template>
  <div>
    <h1>Lego Sets</h1>

    <div class="ui inverted dimmer" v-bind:class="{ active: sets.length == 0 }">
      <div class="ui text loader">Loading</div>
    </div>

    <div class="ui segment">
      <select class="ui dropdown" v-model="selectedThemeID">
        <option v-for="theme in themes" v-bind:value="theme.name">{{ theme.name }}</option>
      </select>
      <div class="ui button" @click="filterSets()">Filter</div>
    </div>

    <template v-if="sets">
      <div class="ui cards">
        <div class="ui card" v-for="(set, index) in sets" :key="index">
          <div class="ui image centered medium">
            <img v-bind:src="set.imageUrl">
          </div>
          <div class="content">
            <div class="header">{{ set.name }}</div>
            <div class="meta">
              <div>{{ set.number }}</div>
              <a v-bind:href="'/set-parts/' + set.number">{{ set.pieces }} Pieces</a>
            </div>
          </div>
          <div class="extra content">
            <span class="right floated">
              {{ set.year }}
            </span>
            <span>
              {{ set.themeName }}
            </span>
          </div>
        </div>
      </div>
      <table class="ui celled striped table">
        <tfoot>
          <tr>
            <th colspan="3">
              <div class="ui right floated pagination menu">
                <a v-bind:class="{ disabled: currentPage == 1}" class="icon item" @click="loadPage(currentPage - 1)">
                  <i class="left chevron icon"></i>
                </a>
                <div class="item">{{ currentPage }}</div>
                <a v-bind:class="{ disabled: sets.length < pageSize}" class="icon item" @click="loadPage(currentPage + 1)">
                  <i class="right chevron icon"></i>
                </a>
              </div>
            </th>
          </tr>
        </tfoot>
      </table>
    </template>
  </div>
</template>

<script>
export default {
  data () {
    return {
      pageSize: 20,
      currentPage: 1,
      sets: [],
      selectedThemeID: '',
      themes: []
    }
  },

  methods: {
    async loadPage(page) {
        console.log(this.sets.length);
      if (page == 0 || (this.sets.length > 0 && this.sets.length < this.pageSize && this.currentPage < page)) {
        console.log("Not doing anything")
        return;
      }
      // ES2017 async/await syntax via babel-plugin-transform-async-to-generator
      this.currentPage = page;
      this.sets = [];

      try {
        let url = `/api/legosets/sets?page=${page}&pagesize=${this.pageSize}`;
        if (this.selectedThemeID != '') {
          url = url + `&theme=${this.selectedThemeID}`;
        }
        let response = await this.$http.get(url)
        console.log(response.data)
        this.sets = response.data;
      } catch (err) {
        window.alert(err)
        console.log(err)
      }
    },
    async filterSets() {
      this.loadPage(1)
    },
    async loadThemes() {
      let response = await this.$http.get(`/api/legosets/themes`);
      console.log(response);
      for (let theme of response.data) {
        console.log(theme);
        this.themes.push(theme);
      }
      this.themes.sort(function (a, b) { return (a.name > b.name) ? 1 : ((b.name > a.name) ? -1 : 0); }); 
    }
  },

  async created() {
    this.loadThemes();
    this.loadPage(1);
  }
}
</script>

<style>
</style>
