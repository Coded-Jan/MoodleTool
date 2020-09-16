# MoodleTool
<b>Important Info: Educational purposes only. I'm not responsible for any damage caused by using this tool!</b>

MoodleTool/MoodleSpammer is a tool that you can use to flood messages to other users in the "Messages"-Section.

<h2>What is Moodle</h2>
Moodle is a learning platform and a "Course-Managment System" primarily for schools. For more information look <a href="https://moodle.org/">here</a>

<h2>How to use</h2>
Maybe there will be a video or screenshots for better explaining in the future.<br>
<ol>
  <li>Login to Moodle on your Browser (Chrome, Firefox, Edge or what you prefer to use)</li>
  <li>Go to the Message-Board and then to the user you want to flood</li>
  <li>Open the Developer-Options (Right click --> Inspect (Element) or F12 on Chrome and Firefox)</li>
  <li>In the Developer-Options, go to "Network". You can now capture all requests done by your Moodle-Session</li>
  <li>In Moodle, you send a message contains any text.</li>
  <li>In the moment you send the message, in the Developer-Options Menu there should appear a few requests. Search for the Request with such a <i>Request URL</i>: "https://(url)/lib/ajax/service.php?sesskey=XXXXXXXXXX&info=core_message_send_messages_to_conversation"</li>
  <li>Start Moodle Tool and enter the following Variables from the Developer-Options into it:
    <ul>
      <li>URL is the URL of the Moodle-Website (e.g. https://yourmoodlewebsite.com/)</li>
      <li>Under General: Request URL --> 10 character long <i>sesskey</i></li>
      <li>Under Request Headers: Cookie --> 32 character long <i>MoodleSession</i></li>
      <li>Under Request Payload --> 0 --> args: <i>conversationid</i> containing digits</li>
    </ul>
  </li>
  <li>Then, enter your message you want to send and the amount of messages that would be sent</li>
  <li>Finally, click on <b>Send Message</b></li>
</ol>

<h2>How it works</h2>
When you login to Moodle, there are 2 Authentication-Keys generated for your Session (<i>sesskey</i> and the <i>MoodleSession</i> Cookie). These keys only changes if you logout from or relogin into your account.
The messages are sent from a simple POST-Request. Every conversation has a unique ID (the <i>conversationid</i>). With these 3 components and the URL of the Moodle-Website, we can easily reconstruct such a request.

<h2>Todo-List</h2>
<ul style="list-style-type: square">
  <li>Background-Threads for Request-sending (prevents Application-Lags on high Amount)</li>
  <li>Save-Option for saving values <i>URL, Amount, convid and Message</i></li>
  <li>Better Exception-Handling (fixes Application-Crashes)</li>
</ul>

<h2>Credits/Libraries</h2>
<a href="https://microsoft.com/">.NET Framework</a><br>
<a href="https://github.com/sourcechord/FluentWPF">FluentWPF 0.8.0</a>
