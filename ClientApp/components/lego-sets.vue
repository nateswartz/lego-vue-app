<template>
  <div>
    <h1>Lego Sets</h1>

    <div class="ui inverted dimmer" v-bind:class="{ active: sets.length == 0 }">
      <div class="ui text loader">Loading</div>
    </div>

    <template v-if="sets">
      <table class="ui celled striped table">
        <thead>
          <tr>
            <th>Number</th>
            <th>Name</th>
            <th>Year</th>
            <th>Theme</th>
            <th>Number of Pieces</th>
            <th>Image</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="(set, index) in sets" :key="index">
            <td>{{ set.set_num }}</td>
            <td>{{ set.name }}</td>
            <td>{{ set.year }}</td>
            <td>{{ set.theme }}</td>
            <td>{{ set.num_parts }}</td>
            <td>
              <a v-bind:href="set.set_url">
                <img class="ui image tiny" v-bind:src="set.set_img_url" />
              </a>
            </td>
          </tr>
        </tbody>
        <tfoot>
          <tr>
            <th colspan="3">
              <div class="ui right floated pagination menu">
                <a class="icon item" @click="loadPage(currentPage - 1)">
                  <i class="left chevron icon"></i>
                </a>
                <div class="item">{{ currentPage }}</div>
                <a class="icon item" @click="loadPage(currentPage + 1)">
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
      sets: []
    }
  },

  methods: {
    async loadPage (page) {
      // ES2017 async/await syntax via babel-plugin-transform-async-to-generator
      this.currentPage = page;
      this.sets = [];

      try {
        var from = (page - 1) * (this.pageSize)
        var to = from + this.pageSize
        let response = await this.$http.get(`/api/legosets/sets?page=${page}&pagesize=${this.pageSize}`)
        console.log(response.data)
        this.sets = response.data;
      } catch (err) {
        window.alert(err)
        console.log(err)
      }
    }
  },

  async created () {
    this.loadPage(1)
  }
}
</script>

<style>
</style>
