using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InterviewQuestionsandAnswers.Startup))]
namespace InterviewQuestionsandAnswers
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
