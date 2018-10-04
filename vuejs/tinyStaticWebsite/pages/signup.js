
//Need to add <script src="https://cdnjs.cloudflare.com/ajax/libs/axios/0.18.0/axios.js"></script>
//for http requests
var SignUp = {
    template: `<div>
                <form @submit.prevent="submit" novalidate>
                   <p>Sisn page</p>
                   <!--INPUT-->
                    <div>
                        <input v-model="name" placeholder="Type name">
                        <p>Types name is: {{ name }}</p>
                    </div>
                        
                    <!--MULTILINE TEXT-->
                    <div>
                        <span>Suggestion:</span>
                        <textarea v-model="suggestion" placeholder="add multiple lines"></textarea>
                    </div>

                    <!--CHECKBOX-->
                    <div>
                        <input type="checkbox" id="checkbox" v-model="isNewUser">
                        <label for="checkbox">Is new user (selected {{isNewUser}})</label>
                    </div>

                    <!--RADIO-->
                    <div>
                        <input type="radio" id="yang" value="Yang" v-model="age">
                        <label for="one">Yang</label>
                        <br>
                        <input type="radio" id="old" value="Old" v-model="age">
                        <label for="two">Old</label>
                        <span>Selected age: {{ age }}</span>
                    </div>

                    <!--DROPDOWN-->
                    <div>
                        <select v-model="gender">
                          <option disabled value="">Please select one</option>
                          <option>Man</option>
                          <option>Woman</option>
                          <option>not sure</option>
                        </select>
                        <span>Selected gender: {{ gender }}</span>
                    </div>
                    
                    <button class="button is-primary">Submit</button>
                    </form>
               </div>`,
    data: function () {
        return {
            name: 'hello message',
            suggestion: 'some suggestion',
            isNewUser: false,
            age: '',
            gender: '',
            submit: function(){
                debugger;
                var parameters = {
                    UserAge: this.$data.age,
                    UserSuggestion: this.$data.suggestion,
                    IsNewUser: this.$data.isNewUser,
                    UserName: this.$data.name,
                    UserGender: this.$data.gender
                };

                console.log('Sending request with parameters:', parameters);
                axios({
                    url: 'https://some-your-url.com',
                    method: 'post',
                    data: parameters
                })
                .then(function (response) {
                    console.log('Successfully send request');

                    //Navigate to different page
                    router.push('/about', function (){
                        console.log('Just navigated to page about');
                    });
                })
                .catch(function (error) {
                    console.log('Failed to send request', error);
                    alert('Failed to send request');
                });
            }
        };
    }
};