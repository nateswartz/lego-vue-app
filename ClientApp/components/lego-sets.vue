<template>
  <div>
    <h1>Lego Sets</h1>

    <div v-if="!sets" class="text-center">
      <p><em>Loading...</em></p>
      <h1><i class="icon spinner" pulse /></h1>
    </div>

    <template v-if="sets">
      <table class="ui celled striped table">
        <thead>
          <tr>
            <th>Number</th>
            <th>Name</th>
            <th>Number of Pieces</th>
            <th>Year</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="(set, index) in sets" :key="index">
            <td>{{ set.set_num }}</td>
            <td>{{ set.name }}</td>
            <td>{{ set.num_parts }}</td>
            <td>{{ set.year }}</td>
          </tr>
        </tbody>
        <tfoot>
          <tr>
            <th colspan="3">
              <div class="ui right floated pagination menu">
                <a class="icon item">
                  <i class="left chevron icon"></i>
                </a>
                <a class="icon item">
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
      sets: null
    }
  },

  methods: {
    async loadPage (page) {
      // ES2017 async/await syntax via babel-plugin-transform-async-to-generator
      // TypeScript can also transpile async/await down to ES5
      this.currentPage = page

      try {
        let response = await this.$http.get(`/api/legosets/sets`)
        console.log(response.data)
        this.sets = response.data
      } catch (err) {
        window.alert(err)
        console.log(err)
      }
    }
  },

  async created () {
    this.loadPage()
  }
}
</script>

<style>
</style>
