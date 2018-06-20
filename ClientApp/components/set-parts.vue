<template>
  <div>
    <h1>Set Parts</h1>

    <div class="ui inverted dimmer" v-bind:class="{ active: searching }">
      <div class="ui text loader">Loading</div>
    </div>

    <div class="ui input">
      <input v-model="setID" placeholder="Enter Set ID" type="text">
    </div>
    <div class="ui button" @click="getParts()">Get Parts</div>

    <img class="ui image small" v-if="set" v-bind:src="set.imageUrl"/>

    <template v-if="parts">
      <table class="ui celled striped table">
        <thead>
          <tr>
            <th>Name</th>
            <th>Color</th>
            <th>Quantity</th>
            <th>Image</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="(part, index) in parts" :key="index">
            <td>{{ part.part.name }}</td>
            <td>{{ part.color.name }}</td>
            <td>{{ part.quantity }}</td>
            <td><img class="ui image tiny" v-bind:src="part.part.part_img_url" /></td>
          </tr>
        </tbody>
        <tfoot>
          <tr>
            <th colspan="3">
              <div class="ui right floated pagination menu">
                <a class="icon item" @click="">
                  <i class="left chevron icon"></i>
                </a>
                <div class="item">x</div>
                <a class="icon item" @click="">
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
    props: ['initialSetID'],
    data () {
      return {
        setID: this.initialSetID,
        searching: false,
        parts: [],
        set: null
      }
    },

    methods: {
      async getParts() {
        this.searching = true;
        let response = await this.$http.get(`/api/legosets/sets/${this.setID}/parts`);
        console.log(response);
        for (let part of response.data) {
          console.log(part);
          this.parts.push(part);
        }
        let setResponse = await this.$http.get(`/api/legosets/sets/${this.setID}`);
        this.set = setResponse.data;
        this.searching = false;
      }
    },
    async created() {
      console.log(this.setID);
      if (this.setID) {
        this.getParts();
      }
    }
  }
</script>

<style>
</style>
